window.onload = function () {
    var text,
        polygon,
        path,
        circle,
        svgNameSpace = 'http://www.w3.org/2000/svg',
        svg;

    function createPath(points, strokeWidth, fill, stroke) {
        var path;
        path = document.createElementNS(svgNameSpace, 'path');
        path.setAttribute('d', points);
        path.setAttribute('stroke-width', strokeWidth);
        path.setAttribute('fill', fill);
        path.setAttribute('stroke', stroke || 'none');
        return path;
    }

    function createCircle(cx, cy, r, fill) {
        var circle;
        circle = document.createElementNS(svgNameSpace, 'circle');
        circle.setAttribute('cx', cx);
        circle.setAttribute('cy', cy);
        circle.setAttribute('r', r);
        circle.setAttribute('fill', fill);
        return circle;
    }

    function createText(innerText, x, y, fontSize, fontWeight, fontFamily, fill) {
        var text;
        text = document.createElementNS(svgNameSpace, 'text');
        text.innerHTML = innerText;
        text.setAttribute('x', x);
        text.setAttribute('y', y);
        text.setAttribute('font-size', fontSize);
        text.setAttribute('font-weight', fontWeight);
        text.setAttribute('font-family', fontFamily);
        text.setAttribute('fill', fill);
        return text;
    }

    function createPolygon(points, style) {
        var polygon;
        polygon = document.createElementNS(svgNameSpace, 'polygon');
        polygon.setAttribute('points', points);
        polygon.setAttribute('style', style);
        return polygon;
    }

    svg = document.getElementById('the-svg');
    text = createText('M', 150, 120, '40px', 'bold', 'consolas', '#3E3F37');
    svg.appendChild(text);
    text = createText('E', 150, 190, '40px', 'bold', 'consolas', 'black');
    svg.appendChild(text);
    text = createText('A', 150, 260, '40px', 'bold', 'consolas', '#E23337');
    svg.appendChild(text);
    text = createText('N', 150, 330, '40px', 'bold', 'consolas', '#8ec74e');
    svg.appendChild(text);
    circle = createCircle(250, 100, 60, '#3E3F37');
    svg.appendChild(circle);
    path = createPath("M 250 80 C220 100 250 130 250 130", '1px', '#5EB14A');
    svg.appendChild(path);
    path = createPath('M 250 80 C280 100 250 130 250 130', '1px', '#449644');
    svg.appendChild(path);
    circle = createCircle(250, 170, 60, 'black');
    svg.appendChild(circle);
    text = createText('express', 205, 180, '24px', 'bold', 'consolas', 'white');
    svg.appendChild(text);
    circle = createCircle(250, 240, 60, '#E23337');
    svg.appendChild(circle);
    path = createPath('M 250 220 L270 230 L250 300', 2, '#B63032', '#B2B4B5');
    svg.appendChild(path);
    path = createPath('M 250 220 L230 230 L250 300', 2, '#E23337', '#B2B4B5');
    svg.appendChild(path);
    path = createPath('M 250 230 L230 280', 2, '#E23337', 'white');
    svg.appendChild(path);
    path = createPath('M 250 230 L270 280', 2, '#E23337', '#B2B4B5');
    svg.appendChild(path);
    circle = createCircle(250, 310, 60, '#8ec74e');
    svg.appendChild(circle);
    polygon = createPolygon('200,329 200,315 210,308 220,315 220,329 214,327 214,320 210,316 206,320 206,327', 'fill:#46473F');
    svg.appendChild(polygon);
    polygon = createPolygon('225,327 225,315 235,308 245,315 245,327 235,333', 'fill:white');
    svg.appendChild(polygon);
    polygon = createPolygon('250,327 250,315 260,308 265,311 265,295 270,300 270,315 270,327 260,333', 'fill:#46473F');
    svg.appendChild(polygon);
    polygon = createPolygon('256,322, 256,319 260,316 264,319 264,322 260,325', 'fill:#8EC74E');
    svg.appendChild(polygon);
    polygon = createPolygon('275,327 275,315 285,308 295,315 289,319 289,322 285,325 295,327 285,333', 'fill:#46473F');
    svg.appendChild(polygon);
    polygon = createPolygon('281,322, 281,319 285,316 289,319 289,322 285,325', 'fill:white');
    svg.appendChild(polygon);
};