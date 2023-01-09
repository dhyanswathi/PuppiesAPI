# PuppiesAPI
# &lt;/salt&gt;

In this exercise you will create a puppy API. 

### The task

Your task is to create a RESTful API with the following endpoints:

- GET: `api/puppies`. This should return a list of all puppies in JSON-format.
- GET: `api/puppies/:id`. This should return one puppy in JSON-format.
- POST: `api/puppies`. This should create and return the newly added puppy.
- PUT: `api/puppies/:id`. This should put one puppy down (jk, just update the specific puppy).
- DELETE: `api/puppies/:id`. This should actually put one puppy down aka delete it.

The database for this task can just be a local array or a real database, it is up to you.

Each `puppy` should have the following attributes: 
    - id
    - breed
    - name
    - birth date

### Testing

Please add tests as TDD rules!
