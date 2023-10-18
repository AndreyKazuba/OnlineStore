const registerButton = document.getElementById('registerButton');
registerButton.addEventListener('click', () => {
    const body = {
        email: document.getElementById('email').value,
        password: document.getElementById('password').value,
        passwordConfirmation: document.getElementById('passwordConfirmation').value
    };

    post('register', body)
        .then(async response => {
            if (response.status == 200) {
                setJwt(await response.json());
                goToMain();
            }
            else if (response.status == 400) {
                showInvalidData();
            }
            else if (response.status == 409) {
                showUserExist();
            }
            else if (response.status == 401) {
                showPasswordIncorrect();
            }
        })
});

const showInvalidData = () => {
    document.getElementById('user-exist').style.display = 'none';
    document.getElementById('incorrect-password').style.display = 'none';
    document.getElementById('invalid-data').style.display = 'block';
};

const showUserExist = () => {
    document.getElementById('user-exist').style.display = 'block';
    document.getElementById('incorrect-password').style.display = 'none';
    document.getElementById('invalid-data').style.display = 'none';
};

const showPasswordIncorrect = () => {
    document.getElementById('user-exist').style.display = 'none';
    document.getElementById('incorrect-password').style.display = 'block';
    document.getElementById('invalid-data').style.display = 'none';
};