"use strict";

app.factory("GearboxTypeResource", function($resource) {
    return $resource("/api/gearboxes");
});