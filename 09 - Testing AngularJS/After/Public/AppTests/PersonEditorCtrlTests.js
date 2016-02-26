describe("The PersonEditorCtrl", function () {
    var ctrl, $scope, $location, person;

    beforeEach(module("myApp"));

    beforeEach(inject(function ($rootScope, $controller, _$location_) {
        $scope = $rootScope.$new();
        $location = _$location_;

        person = { id: 7, $save: function () { } };
        ctrl = $controller("PersonEditorCtrl", {
            $scope: $scope,
            $location: $location,
            person: person
        });

        spyOn(person, "$save");
    }));

    it("can be created", function () {
        expect(ctrl).toBeDefined();
    });

    it("populates the people array", function () {
        expect($scope.currentPerson).toBeDefined();
    });

    it("saves the person on save", function () {
        $scope.save();

        expect(person.$save).toHaveBeenCalled();
    });

    it("doesn't saves the person on cancel", function () {
        $scope.cancel();

        expect(person.$save).not.toHaveBeenCalled();
    });
});

