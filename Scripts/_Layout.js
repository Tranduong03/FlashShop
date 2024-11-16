// Đảm bảo đoạn script được thực thi sau khi DOM đã load
document.addEventListener("DOMContentLoaded", function () {
    const menuItems = document.querySelectorAll('.navbar-con li a');

    menuItems.forEach(item => {
        item.addEventListener('click', function () {
            // Xoá lớp active khỏi tất cả các mục
            menuItems.forEach(link => link.classList.remove('active'));

            // Thêm lớp active vào mục hiện tại
            this.classList.add('active');
        });
    });
});