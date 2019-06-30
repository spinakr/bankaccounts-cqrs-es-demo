import React from "react";

const AccountList = ({ accounts }) => {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>
            <abbr title="Account Id">Id</abbr>
          </th>
          <th>
            <abbr title="Account Name">Name</abbr>
          </th>
          <th>Balance</th>
        </tr>
      </thead>
      <tbody>
        {accounts.map(account => {
          return (
            <tr key={account.accountId}>
              <td>{account.accountId}</td>
              <td>{account.accountName}</td>
              <td>{account.balance}</td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default AccountList;
