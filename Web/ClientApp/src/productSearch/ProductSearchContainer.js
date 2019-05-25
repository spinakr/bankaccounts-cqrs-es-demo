import React, { useState } from "react";
import ProductSearch from "./ProductSearch";
import ProductInfoCard from "../components/ProductInfoCard";

const ProductSearchContainer = () => {
  const [state, setState] = useState({ product: null });

  const searchProduct = async searchInput => {
    let res = await fetch(`api/vinmonopoletProduct/${searchInput}`);
    setState({ product: await res.json() });
  };

  const addProduct = async () => {
    await fetch(`api/inventoryProducts`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(state.product)
    });
  };

  const vintageChange = newVintageValue => {
    setState({ ...state, product: { ...state.product, vintage: newVintageValue } });
  };

  const priceChanged = newPriceValue => {
    setState({ ...state, product: { ...state.product, price: newPriceValue } });
  };

  return (
    <div>
      <div className="section">
        <ProductSearch searchProduct={searchProduct} showAddProductButton={state.product !== null} addProduct={addProduct} />
      </div>
      <div className="section">
        <ProductInfoCard product={state.product} showEditButton={true} vintageChanged={vintageChange} priceChanged={priceChanged} />
      </div>
    </div>
  );
};

export default ProductSearchContainer;
