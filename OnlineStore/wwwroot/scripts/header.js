const logoutBtn = document.getElementById('logoutButton');
const loginBtn = document.getElementById('loginButton');
const logoutBtnMenu = document.getElementById('logoutButtonMenu');
const loginBtnMenu = document.getElementById('loginButtonMenu');

const updateHeaderButtons = () => {
    const jwt = getJwt();
    if (jwt) {
        logoutBtn.style.display = 'block';
        loginBtn.style.display = 'none';

        if (logoutBtnMenu) {
            logoutBtnMenu.style.display = 'block';
            loginBtnMenu.style.display = 'none';
        }
    }
    else {
        if (logoutBtn) {
            logoutBtn.style.display = 'none';
        }
        if (loginBtn) {
            loginBtn.style.display = 'block';
        }
        if (logoutBtnMenu) {
            logoutBtnMenu.style.display = 'none';
            loginBtnMenu.style.display = 'block';
        }
    }
};

if (logoutBtn) {
    logoutBtn.addEventListener('click', () => {
        setIsAdmin(false);
        deleteJwt();
        goToLogin();
    });
}

if (logoutBtnMenu) {
    logoutBtnMenu.addEventListener('click', () => {
        setIsAdmin(false);
        deleteJwt();
        goToLogin();
    });
}

updateHeaderButtons();

const jwt = getJwt();
if (jwt) {

    const cartLink = document.getElementById('cart-link');
    if (cartLink) {
        cartLink.setAttribute('href', '../cart/index.html');
    }
    const cartLinkMenu = document.getElementById('cart-link-menu');
    if (cartLinkMenu) {
        cartLinkMenu.setAttribute('href', '../cart/index.html');
    }
}
else {
    const cartLink = document.getElementById('cart-link');
    if (cartLink) {
        cartLink.setAttribute('href', '../login/index.html');
    }
    const cartLinkMenu = document.getElementById('cart-link-menu');
    if (cartLinkMenu) {
        cartLinkMenu.setAttribute('href', '../login/index.html');
    }
}

const isAdmin = getIsAdmin();
if (isAdmin == 'false') {
    document.getElementById('black-list-link').style.display = 'none';
    document.getElementById('products-link').style.display = 'none';
    document.getElementById('info-link').classList.remove('bordered');
}

const burgerButton = document.getElementById('burger-button');
burgerButton.addEventListener('click', () => {
    document.getElementById('menu').style.display = 'flex';
    setTimeout(() => {
        document.getElementById('menu').style.opacity = 1;
    }, 201);
});