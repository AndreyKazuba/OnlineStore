const getJwt = () => {
    return localStorage.getItem('online-store-jwt');
};

const setJwt = (jwt) => {
    localStorage.setItem('online-store-jwt', jwt);
};

const deleteJwt = () => {
    localStorage.removeItem('online-store-jwt');
};

const getSearchString = () => {
    return localStorage.getItem('online-store-search-string');
};

const setSearchString = (searchString) => {
    localStorage.setItem('online-store-search-string', searchString);
};

const setIsAdmin = (isAdmin) => {
    localStorage.setItem('online-store-is-admin', isAdmin);
};

const getIsAdmin = () => {
    return localStorage.getItem('online-store-is-admin');
};