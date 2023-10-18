const main = document.getElementById('main');
const searchString = getSearchString();
get(`search/${searchString}`, getJwt()).then(async response => {
    if (response.status == 200) {
        const products = await response.json();
        if (products.length) {
            for (const product of products) {
                main.appendChild(createProductCard(product));
            }
        }
        else {
            setEmptyResult();
        }
    }
});

const setEmptyResult = () => {
    document.getElementById('empty-search-label').style.display = 'flex';
};

document.getElementById('search').value = searchString;