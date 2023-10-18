const main = document.getElementById('main');
get('catalog/processors', getJwt()).then(async response => {
    main.innerHTML = '';
    const products = await response.json();
    for (const product of products) {
        main.appendChild(createProductCard(product));
    }
    const footer = document.querySelector('.footer');
    footer.style.display = 'block';
});