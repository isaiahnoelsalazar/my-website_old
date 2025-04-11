const tabs = document.querySelectorAll(".tab");
const contents = document.querySelectorAll(".content");
tabs.forEach(tab => {
    tab.addEventListener("click", () => {
        tabs.forEach(t => {
            t.classList.remove("selected");
            if (t.classList.contains("home_tab")) {
                t.classList.add("unselected");
            }
        });
        tab.classList.add("selected");
        if (tab.classList.contains("home_tab")) {
            tab.classList.remove("unselected");
        }
        contents.forEach((content, i) => {
            content.style.display = i === Array.from(tabs).indexOf(tab) ? "flex" : "none";
        });
    });
});