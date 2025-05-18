// Wake server up
window.addEventListener("load", () => {
    fetch("https://wordsearch-api-sr8i.onrender.com/api/wordsearch")
        .then((response) => {
            if (response.ok) {
                console.log(response);
            } else {
                console.log("Server responded with an error:", response.status);
            }
        })
        .catch((error) => console.error("Error fetching data:", error));
});

const url = "https://wordsearch-api-sr8i.onrender.com/api/wordsearch";

// Generate button 
document.getElementById("generate").addEventListener("click", () => {
    const size = parseInt(document.getElementById("size").value);
    const wordsList = document.getElementById("words").value;

    const words = wordsList
        .split(",")
        .map(w => w.trim().toUpperCase())
        .filter(w => /^[A-Z]+$/.test(w)); 

    const payload = {
        gridSize: size,
        words: words
    };

    fetch(url, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload)
    })
        .then(async response => {
            if (!response.ok) {
                const err = await response.json();
                throw new Error(err.message || "Failed to generate puzzle.");
            }
            return response.json();
        })
        .then(data => {
            renderGrid(data);
            renderWordList(words);
        })
        .catch(error => {
            alert(error.message);
            console.error("Error:", error);
        });
});

// Set the grid
function renderGrid(gridData) {
    const title = document.getElementById("title").value;
    document.getElementById("gridTitle").textContent = title || "WordSearch";

    const grid = document.querySelector(".grid");
    grid.innerHTML = "";

    const gridSize = gridData.length;

    grid.style.display = "grid";
    grid.style.gridTemplateColumns = `repeat(${gridSize}, 1fr)`;
    grid.style.gridTemplateRows = `repeat(${gridSize}, 1fr)`;

    gridData.forEach(row => {
        row.forEach(char => {
            const cell = document.createElement("div");
            cell.classList.add("letter");
            cell.textContent = char;
            grid.appendChild(cell);
        });
    });
}

// Set the word list below the grid
function renderWordList(words) {
    const wordsListContainer = document.querySelector(".words-list");
    wordsListContainer.innerHTML = "";

    let colSize = words.length;
    colSize <= 16 ? colSize = 4 : colSize = 7;

    for (let i = 0; i < words.length; i += colSize) {
        const col = words.slice(i, i + colSize);
        const ul = document.createElement("ul");
        ul.classList.add("words");

        col.forEach(word => {
            const li = document.createElement("li");
            li.textContent = word;
            ul.appendChild(li);
        });

        wordsListContainer.appendChild(ul);
    }
}

// Available characters
const wordsInput = document.getElementById("words");
const charCountDisplay = document.getElementById("characters");

function characterLimit() {
    const size = parseInt(document.getElementById("size").value) || 0;
    const maxChars = Math.floor(size * size * 0.75);
    const input = wordsInput.value;
    const lettersOnly = input.replace(/[^A-Za-z]/g, "");
    const usedChars = lettersOnly.length;
    const remaining = maxChars - usedChars;

    charCountDisplay.textContent = remaining;
    charCountDisplay.style.color = remaining > 0 ? "var(--text-clr-secondary)" : "red";
}

wordsInput.addEventListener("input", characterLimit);
document.getElementById("size").addEventListener("change", characterLimit);

// Grid size
const sizeSelect = document.getElementById("size");

for (let i = 5; i <= 25; i++) {
    const option = document.createElement("option");
    option.value = i;
    option.textContent = `${i} x ${i}`;
    if (i === 10) option.selected = true;
    sizeSelect.appendChild(option);
}

// Set default puzzle
function setDefaultPuzzle() {
    const defaultPuzzle = `NNOPPIHKGEELIDOCORCFABEYEKNOMFVRKLFIIEBANIBVEOHOARDLPERPRPBINOILZFHTOGHATEEHCAOWHANEYHBGNKOLAFFUBAFT`
    const defaultWordList = `lion, leopard, cheetah, rhino, elephant, hippo, giraffe, crocodile, buffalo, zebra, baboon, hyena, gazelle, monkey`
    const wordsArray = defaultWordList.split(",").map(word => word.trim().toUpperCase());
    const wordsListContainer = document.querySelector(".words-list");

    defaultPuzzle.split("").forEach(char => {
        const cell = document.createElement("div");
        cell.classList.add("letter");
        cell.textContent = char;
        document.querySelector(".grid").appendChild(cell);
    })

    for (let i = 0; i < wordsArray.length; i += 4) {
        const col = wordsArray.slice(i, i + 4);
        const ul = document.createElement("ul");
        ul.classList.add("words");

        col.forEach(word => {
            const li = document.createElement("li");
            li.textContent = word;
            ul.appendChild(li);
        });

        wordsListContainer.appendChild(ul);
    }
};

setDefaultPuzzle();

// Print/Save button
document.getElementById("print").addEventListener("click", () => {
    window.print();
});