document.addEventListener("DOMContentLoaded", function () {
    const menuItems = document.querySelectorAll('.navbar-con li a');

    const activeLink = localStorage.getItem('activeLink');
    if (activeLink) {
        document.querySelector(activeLink).classList.add('active');
    }

    menuItems.forEach(item => {
        item.addEventListener('click', function () {
            menuItems.forEach(link => link.classList.remove('active'));

            this.classList.add('active');

            localStorage.setItem('activeLink', '#' + this.id);
        });
    });
});
