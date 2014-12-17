(function() {
  require.config({
    paths: {
      mocha: '../../bower_components/mocha/mocha',
      chai: '../../bower_components/chai/chai',
      controller: '../../scripts/controller',
      sortTests: 'sort-tests',
      pagingTests: 'paging-tests',
      jquery: '../../bower_components/jquery/dist/jquery.min',
      handlebars: '../../bower_components/handlebars/handlebars.min',
      q: '../../libs/q',
      underscore: '../../bower_components/underscore/underscore-min',
      requester: '../../scripts/ajax-requester',
      persisters: '../../scripts/persisters',
      ui: '../../scripts/ui'
    }
  });

  require(['sortTests', 'pagingTests', 'chai', 'mocha'], function(sortTests, pagingTests, chai) {
    mocha.setup('bdd');
    expect = chai.expect;
    sortTests.run();
    pagingTests.run();
    mocha.run();
  });
}());
