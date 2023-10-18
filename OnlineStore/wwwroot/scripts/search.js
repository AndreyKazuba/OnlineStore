const search = document.getElementById('search');
search.addEventListener('keydown', e => {
    if (e.key === 'Enter' && search.value) {
        setSearchString(search.value);
        goToSearch();
    }
});