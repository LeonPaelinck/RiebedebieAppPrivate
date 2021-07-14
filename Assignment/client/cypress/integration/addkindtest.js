describe('Add children tests', function () { 
  
  beforeEach(function () {
    cy.login();
  });
  
  it('mock child post', function() {
    cy.server({ delay: 1000 });
      cy.route({
        method: 'POST',
        url: '/api/children',
        status: 201,
        response: 'SUCCES'
      });
  
      cy.visit('/kind/add');
      cy.get('[data-cy=firstName]').clear().type('Chiara');
      cy.wait(1000);
      cy.get('[data-cy=lastName]').clear().type('Van Campe')
      cy.wait(1000);
      cy.get('[data-cy=addkindButton]').click();
  
    });
  
    it('failed validation', function() {
    
        cy.visit('/kind/add');
        cy.get('[data-cy=firstName]').clear();
        cy.wait(1000);
        cy.get('[data-cy=lastName]').clear();
        cy.wait(1000);
        cy.get('[data-cy=birthDate]').clear();
        cy.wait(1000);
        cy.get('[data-cy=addkindButton]').should('be.disabled');
      });
});
