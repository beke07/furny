/// <reference types="cypress" />

import { clearAndfill, fill } from "./helper";

context("Panelcutter closings", () => {
  before(() => {
    cy.visit("http://localhost:8080");

    fill(cy, 0, "tesztlapszabasz@furny.hu");
    fill(cy, 1, "Asd123.");

    cy.get(".vs-button-relief").click();

    cy.wait(500);
  });

  beforeEach(() => {
    cy.viewport(1500, 1000);

    cy.get(".vs-sidebar--item")
      .eq(3)
      .click();
  });

  it("add", () => {
    add();
  });

  it("edit", () => {
    cy.get(".vs-table--tr")
      .eq(0)
      .dblclick();

    clearAndfill(cy, 0, "Editált élzárás");

    cy.get(".vs-button-relief").click();
  });

  it("delete", () => {
    cy.get(".vs-table--tr")
      .eq(0)
      .click();

    cy.get(".vs-button-border")
      .eq(0)
      .click();

    add();
  });
});

function add() {
  cy.get(".vs-button-border")
    .eq(1)
    .click();

  cy.wait(500);

  clearAndfill(cy, 0, "Teszt élzárás");
  clearAndfill(cy, 1, 2000);

  cy.get(".vs-button-relief").click();
}
