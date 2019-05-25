import React, { useState } from "react";

const ProductInfoCard = ({ product, showEditButton, vintageChanged, priceChanged }) => {
  if (!product) return null;
  const [isEditable, changeIsEditable] = useState(false);
  const renderVintage = () => {
    return isEditable ? (
      <input className="input" style={{ width: "100px" }} value={product.vintage} onChange={e => vintageChanged(e.target.value)} type="number" />
    ) : (
      product.vintage
    );
  };
  const renderPrice = () => {
    return isEditable ? (
      <input className="input" style={{ width: "100px" }} value={product.price} onChange={e => priceChanged(e.target.value)} type="number" />
    ) : (
      product.price
    );
  };

  return (
    <div className="box">
      <article className="media">
        <div className="media-left">
          <figure className="image is-128x128">
            <img src="https://bulma.io/images/placeholders/256x256.png" alt="Placeholder" />
          </figure>
          {showEditButton && (
            <a className="button" onClick={() => changeIsEditable(!isEditable)}>
              Edit
            </a>
          )}
        </div>
        <div className="media-content">
          <div className="content">
            <p className="title">
              {product.name} ({renderVintage()})
            </p>
            <p className="subtitle">
              {product.fruit} - {product.country}
            </p>
            <p>{renderPrice()}</p>
          </div>
        </div>
      </article>
    </div>
  );
};

export default ProductInfoCard;
