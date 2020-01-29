using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using ReactOpenTable.Context;
using System.Data.Common;


//name, date (range), location 

namespace ReactOpenTable.Services
{
    public class InteractionService
    {
        public int Id { get; set; }
        public string Name_input { get; set; }
        public DateTime? Date_input { get; set; }
        public int? Num_assisted { get; set; }
        public string Location { get; set; }
        public string Reject_assistance { get; set; }
        public int? Other{ get; set; }
        public int? Emergency { get; set; }
        public int? Launchpad { get; set; }
        public int? Mission { get; set; }
        public int? Staging { get; set; }
        public string Other_comment { get; set; }



        internal DbAppContext _context { get; set; }

        public InteractionService()
        {

        }

        internal InteractionService(DbAppContext appContext)
        {
            _context = appContext;
        }

        public async Task<List<InteractionService>> GetAsync(string name, DateTime beginDate, DateTime endDate)
        {
            using (var cmd = _context.Connection.CreateCommand())
            {
                cmd.CommandText = @"SELECT `Id`, `Name_input`, `Date_input`, `Num_assisted`, `Location`, `Reject_assistance`, `Other`, `Emergency`, `Launchpad`, `Mission`, `Staging` FROM `INTERACTION` WHERE `Name_input` = @name AND `Location` = @location AND `Date_input` BETWEEN @beginDate AND @endDate";
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@name",
                    DbType = DbType.String,
                    Value = name,
                });
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@beginDate",
                    DbType = DbType.DateTime,
                    Value = beginDate,
                });
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@endDate",
                    DbType = DbType.DateTime,
                    Value = endDate,
                });
                var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
                return result;
            }

        }

        public async Task<InteractionService> GetSingleAsync(int Id)
        {
            using (var cmd = _context.Connection.CreateCommand())
            {
                cmd.CommandText = @"SELECT `Id`, `Name_input`, `Date_input`, `Num_assisted`, `Location`, `Reject_assistance`, `Other`, `Emergency`, `Launchpad`, `Mission`, `Staging` FROM `INTERACTION` WHERE `Id` = @id";
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@id",
                    DbType = DbType.Int32,
                    Value = Id,
                });
                var interactions = new InteractionService();
                var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
                return result.Count > 0 ? result[0] : null;
            }
        }

        public async Task InsertAsync()
        {
            using (var cmd = _context.Connection.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO `INTERACTION` (`Name_input`, `Date_input`, `Num_assisted`, `Location`, `Reject_assistance`, `Other`, `Emergency`, `Launchpad`, `Mission`, `Staging`) VALUES (@name, @date, @numAssisted, @location, @reject_assistance, @other, @emergency, @launchpad, @mission, @staging);";
                BindParams(cmd);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync()
        {
            using (var cmd = _context.Connection.CreateCommand())
            {
                cmd.CommandText = @"UPDATE `INTERACTION` SET `Name_input` = @name, `Date_input` = @date, `Num_assisted` = @numAssisted, `Location` = @location, `Reject_assistance` = @reject_assistance, `Other` = @other, `Emergency` = @emergency, `Launchpad` = @launchpad, `Mission` = @mission, `Staging` = @staging  WHERE `Id` = @id;";
                BindParams(cmd);
                BindId(cmd);
                await cmd.ExecuteNonQueryAsync();
            }

        }

        public async Task DeleteAsync()
        {
            using (var cmd = _context.Connection.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM `INTERACTION` WHERE `Id` = @id;";
                BindId(cmd);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private async Task<List<InteractionService>> ReadAllAsync(DbDataReader reader)
        {
            var interactions = new List<InteractionService>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {

                    var interaction = new InteractionService(_context)
                    {
                        Id = reader.GetInt32(0),
                        Name_input = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                        Date_input = (DateTime?)(!reader.IsDBNull(2) ? reader[2] : null),
                        Num_assisted = !reader.IsDBNull(3) ? (int?)reader.GetInt32(3) : null,
                        Location = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                        Reject_assistance = !reader.IsDBNull(5) ? reader.GetString(5) : null,
                        Other = !reader.IsDBNull(6) ? (int?)reader.GetInt32(6) : null,
                        Emergency = !reader.IsDBNull(7) ? (int?)reader.GetInt32(7) : null,
                        Launchpad = !reader.IsDBNull(8) ? (int?)reader.GetInt32(8) : null,
                        Mission = !reader.IsDBNull(9) ? (int?)reader.GetInt32(9) : null,
                        Staging = !reader.IsDBNull(10) ? (int?)reader.GetInt32(10) : null
                    };
                    interactions.Add(interaction);
                }
            }
            return interactions;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = Name_input,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@date",
                DbType = DbType.DateTime,
                Value = Date_input,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@numAssisted",
                DbType = DbType.Int32,
                Value = Num_assisted,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@location",
                DbType = DbType.String,
                Value = Location,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@reject_assistance",
                DbType = DbType.String,
                Value = Reject_assistance,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@other",
                DbType = DbType.String,
                Value = Other,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@emergency",
                DbType = DbType.Int32,
                Value = Emergency,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@launchpad",
                DbType = DbType.Int32,
                Value = Launchpad,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@mission",
                DbType = DbType.Int32,
                Value = Mission,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@staging",
                DbType = DbType.Int32,
                Value = Staging,
            });
        }
    }
}
