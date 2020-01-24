/**
 * A sample of a main function stating the famous Hello World.
 *
 * @author Simon Westerdahl
 */
function main() {
    let a = 1;
    let b;
    let range = "";
    let x = 0;
    let y = "";

    b = a + 1;

    for (let i=0; i < 9; i++) {
        range += i + ", ";
    }

    while(x != 10) {
        if(x%2 == 0) {
            y += x + ", ";
        }
        x++;
    }

    console.info("Hello World");
    console.info(range.substring(0, range.length - 2));
    console.info(a, b);
    console.info(y.substring(0, y.length-2));
    console.info(Date())
}
main();