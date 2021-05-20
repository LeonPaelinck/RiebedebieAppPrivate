it('mock children get', function() {
    cy.server({ delay: 1000 });
    cy.route({
      method: 'GET',
      url: '/api/children',
      status: 200,
      response: 'fixture:children.json' //4 kinderen
    });

    cy.visit('/');
    cy.get('[data-cy=kindCard]').should('have.length', 4);
  });

  it('on error should show no list', function() {
    cy.server();
    cy.route({
      method: 'GET',
      url: '/api/children',
      status: 500,
      response: 'ERROR'
    });
    cy.visit('/');
    cy.get('[data-cy=kindCard]').should('have.length', 0);
  });