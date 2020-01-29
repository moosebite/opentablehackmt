import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { Mapping } from './components/Mapping';
import { Links } from './components/Links';

export default class App extends Component {
  displayName = App.name
  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/links' component={Links} />
        <Route path='/mapping' component={Mapping} />
      </Layout>
    );
  }
}
