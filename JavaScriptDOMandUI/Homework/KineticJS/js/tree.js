/*jslint browser: true*/
function FamilyMember(initialName) {
    this.name = initialName || null;
    this.sex = null;
    this.father = null;
    this.mother = null;
    this.relation = null;
    this.level = null;
    this.col = null;
    this.children = [];
}

function createNewMemberIfUnique(testedMemberName, familyMembers) {
    var newMember = null,
        membersCount = 0;

    // Check if tested name already exists
    for (membersCount = familyMembers.length - 1; membersCount >= 0; membersCount--) {
        if (familyMembers[membersCount].name === testedMemberName) {
            return null;
        }
    }

    newMember = new FamilyMember(testedMemberName);
    familyMembers.push(newMember);

    return null;
}

function appendMemberToListIfNotNull(newMember, familyMembers) {
    if (!newMember) {
        familyMembers.push(newMember);
    }
}

function buildNodes(inputRelations) {
    var familyMembers = [],
        currentRelation = null,
        relationsCount = 0,
        childrenCount = 0,
        prop = null,
        testedMemberName = null;

    // Traverse each object in input array
    for (relationsCount = inputRelations.length - 1; relationsCount >= 0; relationsCount--) {
        currentRelation = inputRelations[relationsCount];
        for (prop in currentRelation) {
            if (currentRelation.hasOwnProperty(prop)) {
                if (prop === 'children') { // children is array
                    for (childrenCount = currentRelation[prop].length - 1; childrenCount >= 0; childrenCount--) {
                        testedMemberName = currentRelation[prop][childrenCount];
                        createNewMemberIfUnique(testedMemberName, familyMembers);
                    }
                } else {
                    testedMemberName = currentRelation[prop];
                    createNewMemberIfUnique(testedMemberName, familyMembers);
                }
            }
        }
    }

    return familyMembers;
}

function getMember(memberName, membersSet) {
    var i = 0;

    for (i = membersSet.length - 1; i >= 0; i--) {
        if (membersSet[i].name === memberName) {
            return membersSet[i];
        }
    }

    return null;
}

function createNewRelations(familyMembers, currentRelation) {
    var currentFather = null,
        currentMother = null,
        currentChild = null,
        membersCount = 0;

    // Father
    currentFather = getMember(currentRelation.father, familyMembers);
    currentFather.relation = getMember(currentRelation.mother, familyMembers);
    currentFather.sex = 'male';

    // Mother
    currentMother = getMember(currentRelation.mother, familyMembers);
    currentMother.relation = getMember(currentRelation.father, familyMembers);
    currentMother.sex = 'female';

    // Children
    for (membersCount = currentRelation.children.length - 1; membersCount >= 0; membersCount--) {
        currentChild = getMember(currentRelation.children[membersCount], familyMembers);
        currentChild.father = currentFather;
        currentChild.mother = currentMother;
        currentFather.children.push(currentChild);
        currentMother.children.push(currentChild);
    }

    return null;
}

function buildRelations(familyMembers, inputRelations) {
    var relationsCount = 0,
        currentRelation = null;

    for (relationsCount = inputRelations.length - 1; relationsCount >= 0; relationsCount--) {
        currentRelation = inputRelations[relationsCount];
        createNewRelations(familyMembers, currentRelation);
    }
}

function findElder(currentElder) {
    while ((currentElder.father !== null) || (currentElder.relation.father !== null)) {
        currentElder = currentElder.father || currentElder.relation.father;
    }

    return currentElder;
}

function updateLevels(node) {
    var c = 0,
        ELDER_LEVEL = 0,
        stack = [node],
        currentNode = null;

    node.level = ELDER_LEVEL;
    node.relation.level = ELDER_LEVEL;

    while (stack.length > 0) {
        currentNode = stack.pop();
        if (currentNode.father) {
            currentNode.level = (currentNode.father.level || currentNode.mother.level) + 1;
            //console.log(currentNode.level);
            if (currentNode.relation) {
                currentNode.relation.level = currentNode.level;
            }
        }
        for (c = currentNode.children.length - 1; c >= 0; c--) {
            stack.push(currentNode.children[c]);
        }
    }
}