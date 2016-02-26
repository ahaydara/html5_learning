describe("The PeopleListCtrl", function () {
    var ctrl, $scope, $location;

    beforeEach(module("myApp"));

    beforeEach(inject(function ($rootScope, $controller, _$location_) {
        $scope = $rootScope.$new();
        $location = _$location_;
        ctrl = $controller("PeopleListCtrl", {
            $scope: $scope,
            $location: $location,
            people: [{}, {}]
        });
    }));

    it("can be created", function () {
        expect(ctrl).toBeDefined();
    });

    it("populates the people array", function () {
        expect($scope.people.length).toBe(2);
    });

    it("navigates when a person is selected", function () {
        spyOn($location, "path");

        $scope.select({ id: 7 });

        expect($location.path).toHaveBeenCalled();
    });
});
