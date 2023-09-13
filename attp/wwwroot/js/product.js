document.addEventListener('DOMContentLoaded', function () {
    const paginationItems = document.querySelectorAll('.page-item');
    const prevButton = document.querySelector('.product-prev');
    const nextButton = document.querySelector('.product-next');

    let currentPageIndex = 1; 

    function updateCurrentPage(index) {
        paginationItems[currentPageIndex].classList.remove('active');
        currentPageIndex = index;
        paginationItems[currentPageIndex].classList.add('active');
    }

    if (prevButton) {
        prevButton.addEventListener('click', () => {
            if (currentPageIndex > 1) {
                updateCurrentPage(currentPageIndex - 1);
            }
        });
    }

    if (nextButton) {
        nextButton.addEventListener('click', () => {
            if (currentPageIndex < paginationItems.length - 2) {
                updateCurrentPage(currentPageIndex + 1);
            }
        });
    }

    paginationItems.forEach((item, index) => {
        if (index !== 0 && index !== paginationItems.length - 1) {
            item.addEventListener('click', () => {
                updateCurrentPage(index);
            });
        }
    });

    paginationItems[currentPageIndex].classList.add('active');
});
