$('.slider-single').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: true,
    dots: true,
    infinite: true,
    speed: 300,
    adaptiveHeight: true
});
$('.slider-nav').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    arrows: false,
    centerMode: true,
    focusOnSelect: true
});
$(document).ready(function () {
    var quantityInput = $('#quantity');
    var decrementButton = $('#decrement');
    var incrementButton = $('#increment');

    decrementButton.click(function () {
        var currentQuantity = parseInt(quantityInput.val());
        if (currentQuantity > 1) {
            quantityInput.val(currentQuantity - 1);
        }
    });

    incrementButton.click(function () {
        var currentQuantity = parseInt(quantityInput.val());
        quantityInput.val(currentQuantity + 1);
    });

    quantityInput.on('input', function () {
        var currentQuantity = parseInt(quantityInput.val());
        if (isNaN(currentQuantity) || currentQuantity < 1) {
            quantityInput.val(1);
        }
    });
});


const little = document.querySelector.bind(document);
const much = document.querySelectorAll.bind(document);

const tabs = much(".tab-item");
const panes = much(".tab-pane");

const tabActive = little(".tab-item.active");
const line = little(".tabs .line");

requestIdleCallback(function () {
    line.style.left = tabActive.offsetLeft + "px";
    line.style.width = tabActive.offsetWidth + "px";
});

tabs.forEach((tab, index) => {
    const pane = panes[index];

    tab.onclick = function () {
        little(".tab-item.active").classList.remove("active");
        little(".tab-pane.active").classList.remove("active");

        line.style.left = this.offsetLeft + "px";
        line.style.width = this.offsetWidth + "px";

        this.classList.add("active");
        pane.classList.add("active");
    };
});
