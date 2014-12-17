var mongoose = require("mongoose");

var seasonSchema = mongoose.Schema({
  name: {
    type: String,
    required: "{PATH} is required",
    unique: true
  }
});

var Season = mongoose.model("Season", seasonSchema);
