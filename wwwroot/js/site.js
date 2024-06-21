$(document).ready(function () {
    const sidebarToggleBtn = document.querySelector('.sidebar-toggle');
    const sidebar = document.querySelector('.sidebar');
    const mainContent = document.querySelector('.main-content');

    sidebarToggleBtn.addEventListener('click', () => {
        sidebar.classList.toggle('sidebar-closed');
        mainContent.classList.toggle('sidebar-closed');
    });
});