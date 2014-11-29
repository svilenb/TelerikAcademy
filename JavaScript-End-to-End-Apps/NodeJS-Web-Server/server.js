var http = require('http');
var formidable = require('formidable');
var fs = require('fs');
var uuid = require('node-uuid');
var port = 1337;
var UPLOAD_DIRECTORY = './uploads';

var server = http.createServer(function (req, res) {
    res.writeHead(200, {
        'Content-Type': 'text/html'
    });

    if (req.url === '/' && req.method.toLowerCase() === 'get') {
        res.end(
            '<form action="/upload" enctype="multipart/form-data" method="post">' +
            '<input type="file" name="upload"><br>' +
            '<input type="submit" value="Upload">' +
            '</form>');
    } else if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
        var form = new formidable.IncomingForm();
        var fileName;
        form.uploadDir = UPLOAD_DIRECTORY;
        form.encoding = 'utf-8';
        form.keepExtensions = true;
        form.multiples = false;

        if (!fs.existsSync(UPLOAD_DIRECTORY)) {
            fs.mkdirSync(UPLOAD_DIRECTORY);
        }

        form.on('fileBegin', function (name, file) {
            fileName = uuid.v4() + file.name.substring(file.name.indexOf('.'));
            file.path = UPLOAD_DIRECTORY + '/' + fileName;
        });

        form.on('end', function () {
            res.write('<h1>File successfully uploaded.</h1>');
            res.end('<p>Download url <a href="/download/' + fileName + '" >here</a>.</p>');
        });

        form.parse(req);
    } else if (req.url.substr(0, 9) === '/download') {
        var stream = fs.createReadStream(UPLOAD_DIRECTORY + '/' + req.url.substring(10));
        stream.on('error', function (error) {
            res.writeHead(404, {
                'content-type': 'text/plain'
            });
            res.write(http.STATUS_CODES[404]);
            res.end();
        });

        res.writeHead(200);
        stream.pipe(res);
        stream.on('end', function () {
            res.end();
        });
    }
});

server.listen(port);