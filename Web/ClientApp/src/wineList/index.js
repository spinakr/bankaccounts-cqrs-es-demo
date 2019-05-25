import React, { Component } from "react";
import ProductInfoCard from "../components/ProductInfoCard";

class Wines extends Component {
  render() {
    return (
      <div className="columns is-multiline">
        {[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1].map((x, i) => {
          return (
            <div className="column is-one-third">
              <ProductInfoCard key={i} product={{ name: "Wine Name", vintage: "2018", country: "France", fruit: "Pinot Noir", price: "210" }} />
            </div>
          );
        })}
      </div>
    );
  }
}

export default Wines;
