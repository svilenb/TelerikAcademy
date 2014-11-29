module.exports = function (grunt) {
    grunt.initConfig({
        project: {
            app: 'app',
        },
        coffee: {
            compile: {
                files: {
                    'dev/scripts/main.js': '<%= project.app %>/scripts/main.coffee',
                    'dev/scripts/secondary.js': '<%= project.app %>/scripts/secondary.coffee',
                }
            },
        },
        jshint: {
            app: ['dev/scripts/**/*.js']
        },
        uglify: {
            js: {
                files: {
                    'dist/scripts/build.min.js': 'dist/scripts/build.js'
                }
            }
        },
        csslint: {
            app: ['dev/styles/**/*.css']
        },
        cssmin: {
            css: {
                files: {
                    'dist/styles/build.min.css': 'dist/styles/build.css'
                }
            }
        },
        jade: {
            compile: {
                options: {
                    data: {
                        debug: false
                    }
                },
                files: {
                    "dev/index.html": ["<%= project.app %>/index.jade"]
                }
            }
        },
        stylus: {
            app: {
                files: {
                    'dev/styles/main.css': '<%= project.app %>/styles/main.styl',
                    'dev/styles/secondary.css': '<%= project.app %>/styles/secondary.styl'
                }
            }
        },
        copy: {
            dev: {
                files: [{
                    expand: true,
                    src: ['<%= project.app %>/images/**'],
                    dest: 'dev/images/',
                    filter: 'isFile',
                    flatten: true
                }]
            },
            build: {
                files: [{
                    expand: true,
                    src: ['<%= project.app %>/images/**'],
                    dest: 'dist/images/',
                    filter: 'isFile',
                    flatten: true
                }]
            }
        },
        connect: {
            options: {
                port: 9578,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    base: [
						'dev'
                    ]
                }
            }
        },
        watch: {
            coffee: {
                files: ['<%= project.app %>/scripts/**/*.coffee'],
                tasks: ['coffee'],
                options: {
                    livereload: true
                }
            },
            stylus: {
                files: ['<%= project.app %>/styles/**/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            jade: {
                files: ['<%= project.app %>/index.jade'],
                tasks: ['jade'],
                options: {
                    livereload: true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
					'dev/index.html',
					'dev/styles/**/*.css',
					'dev/scripts/**/*.js'
                ]
            }
        },
        concat: {
            js: {
                files: {
                    'dist/scripts/build.js': ['dev/scripts/**/*.js']
                }
            },
            css: {
                files: {
                    'dist/styles/build.css': ['dev/styles/**/*.css']
                }
            }
        },
        htmlmin: {                                     // Task
            dist: {                                      // Target
                options: {                                 // Target options
                    removeComments: true,
                    collapseWhitespace: true
                },
                files: {                                   // Dictionary of files
                    'dist/index.html': 'dev/index.html',     // 'destination': 'source'                    
                }
            },
            dev: {                                       // Another target
                files: {
                    'dist/index.html': 'dev/index.html',
                }
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-csslint');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');

    grunt.registerTask('build', ['coffee', 'stylus', 'jade', 'jshint', 'csslint', 'concat', 'cssmin', 'uglify', 'htmlmin', 'copy:build']);
    grunt.registerTask('serve', ['coffee', 'jshint', 'jade', 'stylus', 'copy:dev', 'connect', 'watch']);
};