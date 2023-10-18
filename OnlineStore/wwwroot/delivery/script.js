const buyButton = document.getElementById('buyButton');
buyButton.addEventListener('click', () => {
    post('buy', {}, getJwt())
        .then(async response => {
            if (response.status == 200) {
                goToOrder();
            }
        })
});

const showInvalidData = () => {
    document.getElementById('invalid-data').style.display = 'flex';
};

const onDelierTypeCheck = () => {
    document.getElementById('address-input').style.display = 'flex';
};

const onSelfTypeCheck = () => {
    document.getElementById('address-input').style.display = 'none';
};

const onCardCheck = () => {
    document.getElementById('card-input').style.display = 'flex';
    document.getElementById('cvv-input').style.display = 'flex';
};

const onCashCheck = () => {
    document.getElementById('card-input').style.display = 'none';
    document.getElementById('cvv-input').style.display = 'none';
};