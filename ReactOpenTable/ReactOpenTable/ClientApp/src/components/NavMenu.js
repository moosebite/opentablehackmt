import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { BottomNavigation, AppBar, BottomNavigationAction } from '@material-ui/core';
import FormatAlignCenterIcon from '@material-ui/icons/FormatAlignCenter';
import PinDropIcon from '@material-ui/icons/PinDrop';
import LinkIcon from '@material-ui/icons/Link';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

    render() {

      return (
          <div style={{display:'flex'}}>
          <AppBar style={{top: 'auto', bottom: '0'}}>
          <BottomNavigation
              showLabels
              className="nav primary"
          >
                      <BottomNavigationAction style={{ outline: '0'}} label="Form" icon={<FormatAlignCenterIcon />} component={Link} to={'/'} />
                      <BottomNavigationAction style={{ outline: '0' }} label="Map" icon={<PinDropIcon />} component={Link} to={'/Mapping'} />
                      <BottomNavigationAction style={{ outline: '0' }} label="Links" icon={<LinkIcon />} component={Link} to={'/Links'} />
          </BottomNavigation>
              </AppBar>
              </div>
     
    /*
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>ReactOpenTable</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/counter'}>
              <NavItem>
                <Glyphicon glyph='education' /> Counter
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/Mapping'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Nashville Map
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
      */
    );
  }
}
