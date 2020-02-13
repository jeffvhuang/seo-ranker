/**
 * Parse string content into HTML DOM to navigate it
 * @param {string} content HTML string content
 * @param {string} url The host/website to rank search against
 */
export function getRanks(content, url) {
    const ranks = [];

    const parser = new DOMParser();
    const html = parser.parseFromString(content, "text/html");
    const mainChildren = html.querySelectorAll('#main > div');

    const childrenArray = [...mainChildren];

    // A div element with just a comment always seems to precede the div before first search result
    const indexComment = childrenArray.findIndex(div => div.children.length < 1);
    let resultNumber = 0;

    for (let i = indexComment + 1; i < childrenArray.length; i++) {
        const resultContainer = childrenArray[i];
        const links = resultContainer.getElementsByTagName('a');

        if (links.length > 0) {
            const isPeopleAlsoAskSection = resultContainer.firstElementChild.innerText.includes('People also ask');

            if (!isPeopleAlsoAskSection) {
                resultNumber++;
                const allText = links[0].innerText.toLowerCase();

                if (allText.includes(url.toLowerCase())) ranks.push(resultNumber);
            }
        }
    }

    return ranks;
}