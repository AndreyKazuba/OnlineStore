const createElement = (elementName, className, content) => {
    const element = document.createElement(elementName);
    if (className) {
        element.classList.add(className);
    }

    if (content) {
        element.innerText = content;
    }

    return element;
};

const imgFoldersMap = {
    1: 'mother_boards',
    2: 'ready_assembly',
    3: 'processors',
    4: 'videocards',
}

const sliceWithDods = (value, symbols) => {
    if (value.length <= symbols) {
        return value;
    }

    return `${value.slice(0, symbols)}...`;
}

const createProductCard = (product) => {
    const itemCard = createElement('div', 'item-card');

    const image = createElement('div', 'image');
    const img = createElement('img');
    img.src = `../img/${imgFoldersMap[product.type]}/${product.imageName}`;
    image.appendChild(img);

    const name = createElement('div', 'name', sliceWithDods(product.name, 25));
    name.title = product.name;
    const description = createElement('div', 'description', sliceWithDods(product.description, 60));
    description.title = product.description;

    const itemFooter = createElement('div', 'item-footer');
    const price = createElement('div', 'price', `${product.price} BYN`);
    let button = null;
    if (product.inCart) {
        button = createElement('div', 'in-cart', 'В корзине');
    }
    else {
        button = createElement('div', 'button', 'В корзину');
        const handler = () => {
            const jwt = getJwt();
            if (jwt) {
                put('cart/items', product.id, jwt);
                button.removeEventListener('click', handler);
                button.classList.remove('button');
                button.classList.add('in-cart');
                button.innerText = 'В корзине';
            }
            else {
                goToLogin();
            }
        };

        button.addEventListener('click', handler);
    }
    
    itemFooter.appendChild(price);
    itemFooter.appendChild(button);

    itemCard.appendChild(image);
    itemCard.appendChild(name);
    itemCard.appendChild(description);
    itemCard.appendChild(itemFooter);

    return itemCard;
};

const createCartItem = product => {
    const cartItem = createElement('div', 'cart-item');

    const image = createElement('div', 'image');
    const img = createElement('img');
    img.src = `../img/${imgFoldersMap[product.type]}/${product.imageName}`;
    image.appendChild(img);

    const content = createElement('div', 'content');
    const name = createElement('div', 'name', product.name);
    const description = createElement('div', 'description', product.description);

    const contentFooter = createElement('div', 'content-footer');
    const price = createElement('div', 'price', `${product.price} BYN`);

    const counter = createElement('div', 'counter');
    const subCircleButton = createElement('div', 'circle-button', '-');
    subCircleButton.addEventListener('click', async () => {
        if (count.innerText == '1') {
            cartItem.style.display = 'none';
            cartItem.classList.add('disabled');
            setEmptyCartLabel();
            await put('cart/items/delete', product.id, getJwt())
            setPlacing();
            return;
        }

        count.innerText = parseInt(count.innerText) - 1;
        setEmptyCartLabel();
        await put('cart/items/reduce-count', product.cartItemId, getJwt());
        setPlacing();
    });
    const count = createElement('div', 'count', product.count);
    const addCircleButton = createElement('div', 'circle-button', '+');
    addCircleButton.addEventListener('click', async () => {
        count.innerText = parseInt(count.innerText) + 1;
        setEmptyCartLabel();
        await put('cart/items/increase-count', product.cartItemId, getJwt());
        setPlacing()
    });
    counter.appendChild(subCircleButton);
    counter.appendChild(count);
    counter.appendChild(addCircleButton);

    contentFooter.appendChild(price);
    contentFooter.appendChild(counter);

    content.appendChild(name);
    content.appendChild(description);
    content.appendChild(contentFooter);

    cartItem.appendChild(image);
    cartItem.appendChild(content);

    return cartItem;
};

const createAdminProductItem = product => {
    const productItem = createElement('div', 'product-item');

    const image = createElement('div', 'image');
    const img = createElement('img');
    img.src = `../img/${imgFoldersMap[product.type]}/${product.imageName}`;
    image.appendChild(img);

    const content = createElement('div', 'content');
    const name = createElement('div', 'name', product.name);
    const description = createElement('div', 'description', product.description);

    const contentFooter = createElement('div', 'content-footer');
    const price = createElement('div', 'price', `${product.price} BYN`);
    const button = createElement('div', 'delete-button', 'Удалить');
    button.addEventListener('click', async () => {
        await post('products/delete', product.id, getJwt());
        location.reload();
    });

    contentFooter.appendChild(price);
    contentFooter.appendChild(button);

    content.appendChild(name);
    content.appendChild(description);
    content.appendChild(contentFooter);

    productItem.appendChild(image);
    productItem.appendChild(content);

    return productItem;
};