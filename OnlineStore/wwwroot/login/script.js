const loginButton = document.getElementById('loginBtn');
loginButton.addEventListener('click', () => {
    const body = {
        email: document.getElementById('email').value,
        password: document.getElementById('password').value,
    };

    post('login', body)
        .then(async response => {
            if (response.status == 200) {
                const result = await response.json(); 
                setJwt(result.jwt);
                setIsAdmin(result.isAdmin)
                goToMain();
            }
            else if (response.status == 400) {
                showInvalidData();
            }
            else if (response.status == 409) {
                showUserDotNotExist();
            }
            else if (response.status == 401) {
                showPasswordIncorrect();
            }
            else if (response.status == 403) {
                showUserBlocked();
            }
        })
});

const showInvalidData = () => {
    document.getElementById('user-not-exist').style.display = 'none';
    document.getElementById('incorrect-password').style.display = 'none';
    document.getElementById('user-blocked').style.display = 'none';
    document.getElementById('invalid-data').style.display = 'block';
};

const showUserDotNotExist = () => {
    document.getElementById('user-not-exist').style.display = 'block';
    document.getElementById('incorrect-password').style.display = 'none';
    document.getElementById('user-blocked').style.display = 'none';
    document.getElementById('invalid-data').style.display = 'none';
};

const showPasswordIncorrect = () => {
    document.getElementById('user-not-exist').style.display = 'none';
    document.getElementById('incorrect-password').style.display = 'block';
    document.getElementById('user-blocked').style.display = 'none';
    document.getElementById('invalid-data').style.display = 'none';
};

const showUserBlocked = () => {
    document.getElementById('user-not-exist').style.display = 'none';
    document.getElementById('user-blocked').style.display = 'block';
    document.getElementById('incorrect-password').style.display = 'none';
    document.getElementById('invalid-data').style.display = 'none';
};