import React, { useState, useEffect } from "react";
import AccountList from "./accountList";

const AccountsContainer = props => {
  const [accounts, setAccounts] = useState([]);

  useEffect(() => {
    async function fetchData() {
      let res = await fetch(`api/customers/${props.match.params.customerId}/accounts`);
      let customerAccounts = await res.json();
      setAccounts(customerAccounts.accounts);
    }
    fetchData();
  }, []);

  return (
    <div className="container">
      <AccountList accounts={accounts} />
    </div>
  );
};

export default AccountsContainer;
