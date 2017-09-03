# This template is based on the framework supplied for a similar challenge, in a Coursera Data Science course: https://www.coursera.org/course/datasci
# And the code supplied here: https://github.com/uwescience/datasci_course_materials/blob/master/assignment3/wordcount.py
import json
import sys
from collections import OrderedDict
class MapReduce:
    def __init__(self):
        self.intermediate = OrderedDict()
        self.result = []
        self.NumRValues = 0

    def emitIntermediate(self, key, value):
        self.intermediate.setdefault(key, [])
        self.intermediate[key].append(value)

    def emit(self, value):
        self.result.append(value) 

    def execute(self, data, mapper, reducer):
        for line in data:
            record = json.loads(line)
            mapper(record)

        for key in self.intermediate:
            reducer(key, self.intermediate[key])

        jenc = json.JSONEncoder()
        for item in self.result:
            print(str(item[0]));
            #print "{\"key\":\""+item[0] +"\",\"value\":" + str(item[1]) + "}" - Simplified for test req
        

mapReducer = MapReduce()

def mapper(record):
    key = record["key"]
    value = record["value"]
    # ADD THE REQUIRED LOGIC BELOW
    # You may need to add some lines for the mapper logic to work
    # At the end, you need to complete the emit intermediate step
    
    # RETURN: Get size of R list and return since we don't need the values for sizes otherwise
    if(key==1):
        mapReducer.NumRValues = int( value.split(" ")[0] )
        #print("NumRValues: " + str(mapReducer.NumRValues)); 
        return;
    
    # Check to see if we are in the R or the S list and return save value accordingly
    if(key <= mapReducer.NumRValues):
        mapReducer.emitIntermediate(value.rstrip(), "R");
    else:
        mapReducer.emitIntermediate(value.rstrip(), "S");

def reducer(key, list_of_values):
    # ADD THE REQUIRED LOGIC BELOW
    # You may need to add some lines for the reducer logic to work
    # At the end, you need to complete the emit step
    #if(len(list_of_values) > 1):
    if(("R" in list_of_values) and ("S" in list_of_values)):
        mapReducer.emit((key, list_of_values))


if __name__ == '__main__':
  inputData = []
  counter = 0
  for line in sys.stdin:
   counter += 1
   inputData.append(json.dumps({"key":counter,"value":line}))
  mapReducer.execute(inputData, mapper, reducer)
