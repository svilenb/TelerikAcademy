define(['controller'], function(Controller) {
  function runSortTests() {
    describe('Sort', function() {
      function isSortedAscending(collection, prop) {
        for (var i = 1; i < collection.length; i += 1) {
          if (collection[i - 1][prop] > collection[i][prop]) {
            return false;
          }
        }

        return true;
      }

      function isSortedDescending(collection, prop) {
        for (var i = 1; i < collection.length; i += 1) {
          if (collection[i - 1][prop] < collection[i][prop]) {
            return false;
          }
        }

        return true;
      }

      describe('by title', function() {
        it('with posts ascending, expect sorted', function() {
          var controller = new Controller(),
            posts = [{
              title: 'Spam'
            }, {
              title: 'Trash'
            }, {
              title: 'Hello'
            }],
            sortedPosts = controller.sortPosts(posts, 'title', true);

          expect(isSortedAscending(sortedPosts, 'title')).to.be.ok;
        });

        it('without posts ascending, expect sorted', function() {
          var controller = new Controller(),
            posts = [],
            sortedPosts = controller.sortPosts(posts, 'title', true);

          expect(isSortedAscending(sortedPosts, 'title')).to.be.ok;
        });

        it('with posts descending, expect sorted', function() {
          var controller = new Controller(),
          posts = [{
            title: 'Spam'
          }, {
            title: 'Trash'
          }, {
            title: 'Hello'
          }],
          sortedPosts = controller.sortPosts(posts, 'title', false);

          expect(isSortedDescending(sortedPosts, 'title')).to.be.ok;
        });

        it('without posts descending, expect sorted', function() {
          var controller = new Controller(),
          posts = [],
          sortedPosts = controller.sortPosts(posts, 'title', false);

          expect(isSortedDescending(sortedPosts, 'title')).to.be.ok;
        });
      });

      describe('by date', function() {
        it('with posts ascending, expect sorted', function() {
          var controller = new Controller(),
          posts = [{
            postDate: '2014-12-14T18:34:56.404Z'
          }, {
            postDate: '2014-12-14T18:35:54.473Z'
          }, {
            postDate: '2014-12-14T21:27:48.074Z'
          }],
          sortedPosts = controller.sortPosts(posts, 'postDate', true);

          expect(isSortedAscending(sortedPosts, 'postDate')).to.be.ok;
        });

        it('without posts ascending, expect sorted', function() {
          var controller = new Controller(),
          posts = [],
          sortedPosts = controller.sortPosts(posts, 'postDate', true);

          expect(isSortedAscending(sortedPosts, 'postDate')).to.be.ok;
        });

        it('with posts descending, expect sorted', function() {
          var controller = new Controller(),
          posts = [{
            postDate: '2014-12-14T18:34:56.404Z'
          }, {
            postDate: '2014-12-14T18:35:54.473Z'
          }, {
            postDate: '2014-12-14T21:27:48.074Z'
          }],
          sortedPosts = controller.sortPosts(posts, 'postDate', false);

          expect(isSortedDescending(sortedPosts, 'postDate')).to.be.ok;
        });

        it('without posts descending, expect sorted', function() {
          var controller = new Controller(),
          posts = [],
          sortedPosts = controller.sortPosts(posts, 'postDate', false);

          expect(isSortedDescending(sortedPosts, 'postDate')).to.be.ok;
        });
      });
    });
  }

  return {
    run: runSortTests
  };
});
