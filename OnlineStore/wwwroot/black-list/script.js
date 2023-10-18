const updateUsersElement = () => {
    const usersElement = document.getElementById('users');
    usersElement.innerHTML = '';
    get('users', getJwt()).then(async response => {
        const users = await response.json();
        for (const user of users) {
            usersElement.appendChild(createUserItem(user));
        }
    });
};

const createUserItem = (user) => {
    const userItem = createElement('div', 'user');

    const email = createElement('div', 'email', user.email);
    const status = createElement('div', 'status');

    const statusLabel = createElement('div', 'status-label');
    if (user.isBlocked) {
        statusLabel.classList.add('blocked');
        statusLabel.innerText = 'заблокирован';
    }
    else {
        statusLabel.classList.add('active');
        statusLabel.innerText = 'активен';
    }

    status.appendChild(statusLabel);

    const button = createElement('div', 'button');
    if (user.isBlocked) {
        button.innerText = 'Разблокировать';
        button.addEventListener('click', () => {
            post('users/unblock', user.id, getJwt()).then(() => {
                updateUsersElement();
            });
        });
    }
    else {
        button.innerText = 'Заблокировать';
        button.addEventListener('click', () => {
            post('users/block', user.id, getJwt()).then(() => {
                updateUsersElement();
            });
        });
    }

    userItem.appendChild(email);
    userItem.appendChild(status);
    userItem.appendChild(button);

    return userItem;
};

updateUsersElement();

{/* <div class="user">
                <div class="email">test@test.com</div>
                <div class="status">
                    <div class="status-label active">активен</div>
                </div>
                <div class="button block">Заблокировать</div>
            </div>
            <div class="user">
                <div class="email">test@test.com</div>
                <div class="status">
                    <div class="status-label blocked">заблокирован</div>
                </div>
                <div class="button unblock">Разблокировать</div>
            </div> */}