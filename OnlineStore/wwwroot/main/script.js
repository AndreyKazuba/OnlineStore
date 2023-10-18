const main = document.getElementById('main');
get('bestsellers', getJwt()).then(async response => {
    const placeholders = document.getElementsByClassName('placeholder');
    for (let i = 0; i < placeholders.length; i++) {
        placeholders[i].style.display = 'none';
    }
    const bestsellers = await response.json();
    for (const bestseller of bestsellers) {
        main.appendChild(createProductCard(bestseller));
    }
    const footer = document.querySelector('.footer');
    footer.style.display = 'block';
});