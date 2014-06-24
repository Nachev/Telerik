/*jslint browser: true*/
window.onload = function() {
    var stage = new Kinetic.Stage({
        container: 'canvas-container',
        width: window.innerWidth,
        height: window.innerHeight
    }),
        layer = new Kinetic.Layer(),
        familyTree = [],
        theElder = null,
        COL_WIDTH = 220,
        LABEL_WIDTH = 180,
        LABEL_HEIGHT = 30;

    function drawParentChildRelation(child) {
        var parentRelation = null,
            childX = child.col + LABEL_WIDTH / 2,
            childY = child.level * LABEL_HEIGHT * 2,
            motherX = child.mother.col + LABEL_WIDTH / 2,
            motherY = child.mother.level * LABEL_HEIGHT * 2 + LABEL_HEIGHT,
            fatherX = child.father.col + LABEL_WIDTH / 2,
            fatherY = child.father.level * LABEL_HEIGHT * 2 + LABEL_HEIGHT;

        parentRelation = new Kinetic.Line({
            points: [fatherX, fatherY, childX, childY, motherX, motherY],
            stroke: 'black',
            strokeWidth: 2,
            lineJoin: 'square'
        });

        layer.add(parentRelation);
    }

    function drawRelation(secondNode) {
        var relation = null,
            y = secondNode.level * LABEL_HEIGHT * 2 + LABEL_HEIGHT / 2;

        relation = new Kinetic.Line({
            points: [secondNode.col, y, secondNode.col - COL_WIDTH + LABEL_WIDTH, y],
            stroke: 'black',
            strokeWidth: 2,
            lineJoin: 'round'
        });

        layer.add(relation);
    }

    function drawNode(currentNode) {
        var text = null,
            labelRect = null,
            linePointsMale = [],
            linePointsFemale = [],
            currentX = currentNode.col,
            currentY = currentNode.level * LABEL_HEIGHT * 2;

        labelRect = new Kinetic.Rect({
            x: currentX,
            y: currentY,
            width: LABEL_WIDTH,
            height: LABEL_HEIGHT,
            strokeWidth: 2,
            stroke: 'green',
            cornerRadius: currentNode.sex === 'female' ? 15 : 10,
        });

        text = new Kinetic.Text({
            x: currentX,
            y: currentY + LABEL_HEIGHT / 4,
            text: currentNode.name,
            width: LABEL_WIDTH,
            fontSize: 16,
            fontFamily: 'Consolas',
            align: 'center',
            fill: 'purple'
        });

        layer.add(text);
        layer.add(labelRect);
    }

    function drawTree(node) {
        var c = 0,
            queue = [node],
            currentNode = null,
            previousNode = node,
            col = 20;

        while (queue.length > 0) {
            relation = '';
            currentNode = queue.shift();

            // Determine column
            if (currentNode.level === previousNode.level) {
                col = col + COL_WIDTH;
            } else {
                col = 20;
            }

            currentNode.col = col;
            drawNode(currentNode);
            if (currentNode.relation) {
                col = col + COL_WIDTH;
                currentNode.relation.col = col;
                drawNode(currentNode.relation);
                drawRelation(currentNode.relation);
            }
            previousNode = currentNode;

            if (currentNode.father) {
                drawParentChildRelation(currentNode);
            }

            for (c = currentNode.children.length - 1; c >= 0; c--) {
                queue.push(currentNode.children[c]);
            }
        }

        return null;
    }

    familyTree = buildNodes(testCase1);
    buildRelations(familyTree, testCase1);

    theElder = familyTree[0];
    theElder = findElder(theElder);

    updateLevels(theElder);
    drawTree(theElder);

    stage.add(layer);
};