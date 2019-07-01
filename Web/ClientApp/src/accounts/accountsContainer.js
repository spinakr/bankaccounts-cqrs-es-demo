import React, { useState, useEffect } from "react";
import AccountList from "./accountList";
import TransferComponent from "./transferComponent";

const AccountsContainer = props => {
  const emptyTransfer = { to: "", from: "", amount: "" };
  const [accounts, setAccounts] = useState([]);
  const [transfer, setTransfer] = useState(emptyTransfer);

  const fetchAccountData = () => {
    fetch(`api/customers/${props.match.params.customerId}/accounts`)
      .then(res => {
        return res.json();
      })
      .then(json => {
        setAccounts(json.accounts);
      });
  };

  useEffect(() => {
    fetchAccountData();
  }, []);

  const updateTransfer = accountId => {
    if (transfer.from === "") {
      setTransfer({ ...transfer, from: accountId });
    } else {
      setTransfer({ ...transfer, to: accountId });
    }
  };

  const amountChanged = newAmount => {
    setTransfer({ ...transfer, amount: newAmount });
  };

  const executeTransfer = async () => {
    await fetch(`api/customers/${props.match.params.customerId}/accounts/transfer`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        FromAccountId: transfer.from,
        ToAccountId: transfer.to,
        Amount: transfer.amount
      })
    });
    setTransfer(emptyTransfer);
    await fetchAccountData();
  };

  return (
    <div>
      <AccountList accounts={accounts} updateTransfer={updateTransfer} />
      <TransferComponent
        amount={transfer.amount}
        fromAccount={transfer.from}
        toAccount={transfer.to}
        executeTransfer={executeTransfer}
        amountChanged={amountChanged}
      />
    </div>
  );
};

export default AccountsContainer;
