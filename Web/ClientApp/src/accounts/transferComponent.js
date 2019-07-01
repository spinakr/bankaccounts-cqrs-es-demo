import React from "react";

const TransferComponent = ({ fromAccount, toAccount, amount, amountChanged, executeTransfer }) => {
  return (
    <div className="field is-horizontal is-grouped">
      <p className="control">
        <input className="input is-primary is-normal" type="text" placeholder="From account number" readOnly value={fromAccount} />
      </p>
      <p className="control">
        <input className="input is-primary is-normal" type="text" placeholder="To account number" readOnly value={toAccount} />
      </p>
      <p className="control">
        <input
          className="input is-primary is-normal"
          type="number"
          placeholder="Amount"
          value={amount}
          onChange={e => amountChanged(e.target.value)}
        />
      </p>
      <p className="control">
        <a className="button is-primary" onClick={async () => await executeTransfer()}>
          Transfer
        </a>
      </p>
    </div>
  );
};

export default TransferComponent;
