function Day() {
    this.date = null,
        this.hours = [];
    this.ASIPortal = {
        bugs: [],
        tasks: [],
        changesets: []
    };
    this.TSNPortal = {
        bugs: [],
        tasks: [],
        changesets: []
    };
};

function standardDate() {
    var d = new Date();
    d.setHours(12);
    d.setMinutes(0);
    return d;
}

var app = angular.module("app", ['ui.bootstrap']);
app.controller("MainController", function ($scope, $http) {
    $scope.model = [new Day()];
    $scope.workOptions = ["Task", "Bug", "Changeset"];

    $scope.addADay = function () {
        $scope.model.push(new Day());
    }

    $scope.addRange = function (day) {
        if (!day.lastDate) {
            day.lastDate = standardDate();
        }
        day.hours.push({
            start: day.lastDate,
            end: day.lastDate
        });
    }

    $scope.adjustRangeEnd = function (range) {
        range.end = range.start;
    }

    $scope.updateLastDate = function (day, lastDate) {
        day.lastDate = lastDate;
    }

    $scope.addWorkItem = function (project) {
        switch (project.currentWorkItem.type) {
            case "Task":
                project.tasks.push({ number: project.currentWorkItem.number });
                break;
            case "Bug":
                project.bugs.push({ number: project.currentWorkItem.number });
                break;
            case "Changeset":
                project.changesets.push({ number: project.currentWorkItem.number });
                break;
        }
        project.workOptions = false;
    }

    $scope.submit = function () {
        $http.post("/Home/Go", { days: $scope.model })
            .then(function (response) {
                window.location = response.data.place;
            });
    }
});

app.directive('project', function () {
    return {
        restrict: 'E',
        scope: {
            project: '=info',
            addWorkItem: '=adder',
            workOptions: '=workOptions',
            projectName: '=pName',
            dayIndex: '@dayIndex'
        },
        templateUrl: '/Scripts/app/project.html'
    };
});

app.directive('projectDisplay', function () {
    return {
        restrict: 'E',
        scope: {
            project: '=info',
            projectName: '=pName'
        },
        templateUrl: '/Scripts/app/project-display.html'
    };
});
