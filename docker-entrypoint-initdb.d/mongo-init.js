print("Started Adding the Users.");
db = db.getSiblingDB("admin");
db.createUser({
  user: "user",
  pwd: "secret",
  roles: [{ role: "readWrite", db: "VehicleStore" }],
});
print("End Adding the User Roles.");
