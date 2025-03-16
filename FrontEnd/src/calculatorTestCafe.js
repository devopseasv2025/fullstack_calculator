import { Selector } from "testcafe";

fixture("Calculator tests").page("http://localhost:8080/");

test("Select Chaced Calculator", async t => {
    await t
        .click(Selector("#root > div:nth-child(1) > button:nth-child(5)"))
        .expect(Selector('p').innerText).contains('1');
});