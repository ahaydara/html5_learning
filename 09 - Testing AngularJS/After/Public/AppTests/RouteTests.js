describe("The app routing", function () {
    var $route;

    beforeEach(module("myApp"));

    beforeEach(inject(function (_$route_) {
        $route = _$route_;
    }));

    it('should map /people to PeopleListCtrl', function () {
        expect($route.routes['/people'].controller)
            .toBe('PeopleListCtrl');
        expect($route.routes['/people'].templateUrl)
            .toEqual('/Templates/PeopleList.html');
    });

    it('should map /person/:id to PersonEditorCtrl', function () {

        expect($route.routes['/person/:id'].templateUrl)
            .toEqual('/Templates/PersonEditor.html');
        expect($route.routes['/person/:id'].controller)
            .toEqual('PersonEditorCtrl');
    });

    it('should map unkown routes to /people', function () {
        expect($route.routes[null].redirectTo)
            .toEqual('/people');
    });
});
