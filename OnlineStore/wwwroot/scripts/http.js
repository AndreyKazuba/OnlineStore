const put = async (url, body, jwt) => {
    const response = await fetch(`/api/${url}`, {
        method: 'PUT',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json', 'Authorization': `Bearer ${jwt}` },
        body: body ? JSON.stringify(body) : null,
    });

    return response;
};

const post = async (url, body, jwt) => {
    const response = await fetch(`/api/${url}`, {
        method: 'POST',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json', 'Authorization': `Bearer ${jwt}` },
        body: body ? JSON.stringify(body) : null,
    });

    return response;
};

const get = async (url, jwt) => {
    const response = await fetch(`/api/${url}`, {
        method: 'GET',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json', 'Authorization': `Bearer ${jwt}` },
    });

    return await response;
};