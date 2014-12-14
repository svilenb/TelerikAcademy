define(['controller'], function(Controller) {
  function runPagingTests() {
    describe('Paging', function() {
      function areEqualCollections(firstCollection, secondCollection, prop) {
        if (firstCollection.length !== secondCollection.length) {
          return false;
        }

        for (var i = 0; i < firstCollection.length; i += 1) {
          if (firstCollection[i][prop] !== secondCollection[i][prop]) {
            return false;
          }
        }

        return true;
      }

      describe('with posts', function() {
        describe('first page', function() {
          it('when enough posts, expect full page with correct posts', function() {
            var controller = new Controller(),
              posts = [{
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }];

            showedPosts = controller.getPostsOnPage(posts, 1, 4);

            expect(areEqualCollections(posts.slice(0, 4), showedPosts, 'title')).to.be.ok;
          });

          it('when not enough posts, expect partially full page with correct posts', function() {
            var controller = new Controller(),
              posts = [{
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }];

            showedPosts = controller.getPostsOnPage(posts, 1, 4);

            expect(areEqualCollections(posts, showedPosts, 'title')).to.be.ok;
          });
        });

        describe('bigger than first page', function() {
          it('when enough posts, expect full page with correct posts', function() {
            var controller = new Controller(),
              posts = [{
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }];

            showedPosts = controller.getPostsOnPage(posts, 3, 4);

            expect(areEqualCollections(posts.slice(8, 12), showedPosts, 'title')).to.be.ok;
          });

          it('when not enough posts, expect partially full page with correct posts', function() {
            var controller = new Controller(),
              posts = [{
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }, {
                title: 'Trash'
              }, {
                title: 'Hello'
              }, {
                title: 'Spam'
              }];

            showedPosts = controller.getPostsOnPage(posts, 3, 4);

            expect(areEqualCollections(posts.slice(8, 10), showedPosts, 'title')).to.be.ok;
          });
        });

        it('when zero page, expect empty page with no posts', function() {
          var controller = new Controller(),
            posts = [{
              title: 'Spam'
            }, {
              title: 'Trash'
            }, {
              title: 'Hello'
            }, {
              title: 'Spam'
            }];

          showedPosts = controller.getPostsOnPage(posts, 0, 4);

          expect(areEqualCollections([], showedPosts, 'title')).to.be.ok;
        });

        it('when negative page, expect empty page with no posts', function() {
          var controller = new Controller(),
            posts = [{
              title: 'Spam'
            }, {
              title: 'Trash'
            }, {
              title: 'Hello'
            }, {
              title: 'Spam'
            }];

          showedPosts = controller.getPostsOnPage(posts, -3, 4);

          expect(areEqualCollections([], showedPosts, 'title')).to.be.ok;
        });
      });

      describe('without posts', function() {

      });
    });
  }

  return {
    run: runPagingTests
  };
});
