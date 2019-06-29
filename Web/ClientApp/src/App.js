import React from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import Accounts from "./accounts";

export default () => {
  return (
    <Layout>
      <Route exact path="/" />
      <Route path="/accounts/:customerId" component={Accounts} />
    </Layout>
  );
};
