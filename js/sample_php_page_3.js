let cart = [];

function updateCartCount() {
    const cartCountElement = document.getElementById("cart-count");
    cartCountElement.textContent = cart.reduce((sum, item) => sum + item.quantity, 0);
}

function addToCart(product) {
    const existingItem = cart.find(item => item.id === product.id);
    if (existingItem) {
        existingItem.quantity++;
    } else {
        cart.push({ ...product, quantity: 1 });
    }
    updateCartCount();
    console.log(cart);
}

document.addEventListener("DOMContentLoaded", () => {
    const addButtons = document.querySelectorAll(".add-to-cart");

    addButtons.forEach(button => {
        button.addEventListener("click", (e) => {
            const productElement = e.target.closest(".product");
            const id = productElement.dataset.id;
            const name = productElement.dataset.name;
            const price = parseFloat(productElement.dataset.price);

            const product = { id, name, price };
            addToCart(product);
        });
    });

    updateCartCount();
});