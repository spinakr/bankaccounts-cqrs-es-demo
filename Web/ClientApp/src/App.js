import React from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import WineList from "./wineList";
import ProductSearch from "./productSearch";

export default () => {
  return (
    <Layout>
      <Route exact path="/" />
      <Route path="/wines" component={WineList} />
      <Route path="/search" component={ProductSearch} />
    </Layout>
  );
};
