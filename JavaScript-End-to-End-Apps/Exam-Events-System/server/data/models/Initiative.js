var mongoose = require("mongoose");

var initiativeSchema = mongoose.Schema({
  name: {
    type: String,
    required: "{PATH} is required",
    unique: true
  }
});

var Initiative = mongoose.model("Initiative", initiativeSchema);
