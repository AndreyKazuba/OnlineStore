const cartItems = document.getElementById('cart-items');
get('cart/items', getJwt()).then(async response => {
    const products = await response.json();
    for (const product of products) {
        cartItems.appendChild(createCartItem(product));
    }

    setPlacing();
    setEmptyCartLabel();
});

const setEmptyCartLabel = () => {
    if (document.querySelectorAll('.cart-item:not(.cart-item.disabled)').length === 0) {
        document.getElementById('empty-cart-label').style.display = 'block';
        document.getElementById('placing').style.display = 'none';
    }
    else {
        document.getElementById('empty-cart-label').style.display = 'none';
        document.getElementById('placing').style.display = 'block';
    }
};

const setPlacing = () => {
    get('cart/items', getJwt()).then(async response => {
        const products = await response.json();
        if (products && products.length) {
            const price = products.map(product => {
                product.price = product.price * product.count;
                return product;
            }).map(product => product.price).reduce((partialSum, a) => partialSum + a, 0);
            const count = products.map(product => product.count).reduce((partialSum, a) => partialSum + a, 0);
            document.getElementById('result').innerText = `${price} BYN`;
            document.getElementById('result-price').innerText = `${price} BYN`;
            document.getElementById('products-count').innerText = `Товары - ${count}шт.`;
        }
    });
};