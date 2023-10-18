const productItems = document.getElementById('product-items');
get('products', getJwt()).then(async response => {
    const products = await response.json();
    for (const product of products) {
        productItems.appendChild(createAdminProductItem(product));
    }
});

const createNewButton = document.getElementById('createNewButton');
createNewButton.addEventListener('click', () => {
    const body = {
        name: document.getElementById('name').value,
        description: document.getElementById('description').value,
        price: document.getElementById('price').value,
        type: document.querySelector('input[name="product-type"]:checked').value,
    };

    post('products', body, getJwt())
        .then(response => {
            if (response.status == 200) {
                location.reload();
            }
            else if (response.status == 400) {
                showInvalidData();
            }
        })
});

const showInvalidData = () => {
    document.getElementById('invalid-data').style.display = 'block';
};